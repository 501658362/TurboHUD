﻿namespace Turbo.Plugins.glq
{
    using System.Collections.Generic;
    using Turbo.Plugins.Default;
    public class GLQ_BuffLabelsPlugin : BasePlugin, IInGameTopPainter
    {
        public bool ShowIgnorePain { get; set; }
        //public bool ShowOculus { get; set; }
		
        public bool ChangeTextSize { get; set; }

        public float YPos { get; set; }
        public float XPos { get; set; }
        public float SizeModifier { get; set; }
        public float TextSize { get; set; }
        public float JumpDistance { get; set; }
        public float SmoothSpeed { get; set; }
        public int NumRows { get; set; }

        public float YPosIncrement { get; set; }

        public bool Debug { get; set; }
        public bool SmoothMovement { get; set; }

        public IFont TextFont { get; set; }
        public IBrush BorderBrush { get; set; }
        public IBrush BackgroundBrushIP { get; set; }
        //public IBrush BackgroundBrushOC { get; set; }

		
        public List<Label> Labels { get; set; }

        private float _yPosTemp, _xPosTemp, _xPosGoal, _labelWidthPercentage, _labelHeightPercentage, _jumpCount;
        private bool _debugStarted, _debugDone, _debugAlreadyAdded;
        private int _debugAddShifter = 0, _activeBuffsCount = 0;

        private float hudWidth { get { return Hud.Window.Size.Width; } }
        private float hudHeight { get { return Hud.Window.Size.Height; } }
        private float lWidth { get { return hudWidth * _labelWidthPercentage * SizeModifier; } }
        private float lHeight { get { return hudHeight * _labelHeightPercentage * SizeModifier; } }

        private List<Label> _debugLabels;
        private IWatch debugWatch;

        public GLQ_BuffLabelsPlugin()
        {
            Enabled = true;

        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            //Turn labels on and off
            ShowIgnorePain = false;
            //ShowOculus = true;


			
            //Horizontal and Vertical label positions.
            YPos = 0.65f;
            XPos = 0.5f;

            SizeModifier = 1f;
            TextSize = 8;
            JumpDistance = 1.07f;
            NumRows = 1;

            //Label size is based on a percentage of screen width/height
            _labelWidthPercentage = 0.040f;
            _labelHeightPercentage = 0.018f;

            //Vertical distance between labels
            YPosIncrement = 0.021f;

            //If true labels are always shown
            Debug = false;
            SmoothMovement = true;
            SmoothSpeed = 0.05f;
            debugWatch = Hud.Time.CreateWatch();
            debugWatch.Restart();

            BorderBrush = Hud.Render.CreateBrush(150, 30, 30, 30, 0);

            //BackgroundBrushIP = Hud.Render.CreateBrush(100, 100, 225, 100, 0);   // Ignore Pain

			
            Labels = new List<Label>();

            //Labels.Add(new Label("神目指环", 402461, 2, BackgroundBrushOC, ShowOculus));

			
            _jumpCount = 1;
            _yPosTemp = YPos;
            _xPosTemp = XPos;
            if (NumRows < 1) NumRows = 1;
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;

            //Allow changing font size from a customize method by instatiating here instead of in Load
            if (TextFont == null)
            {
                TextFont = Hud.Render.CreateFont("tahoma", TextSize * SizeModifier, 240, 240, 240, 240, true, false, true);
            }

            //Draw all labels
            foreach (Label l in Labels)
                if (l.Show && (Hud.Game.Me.Powers.BuffIsActive((uint)l.Sno, l.IconCount) || Debug))
                    DrawLabel(l.LabelBrush, l.NameText);

            //Avoid potentially showing two IP labels. TODO: Find a better way to do this - without adding a list of conditions to the Label class since this would make adding new buffs more complex.
            if (ShowIgnorePain && (Hud.Game.Me.Powers.BuffIsActive(79528, 0) || Hud.Game.Me.Powers.BuffIsActive(79528, 1)) || Debug)
                DrawLabel(BackgroundBrushIP, "无视苦痛");
			

            //Smooth horizontal movement
            CalculateXPosTemp();
            
            //Reset vars
            _yPosTemp = YPos;
            _jumpCount = 0;
            _activeBuffsCount = 0;

            //Add labels one by one if debug
            if (Debug && !_debugDone)
            {
                DebugTimedAdd();
            }
        }

        private void DrawLabel(IBrush label, string buffText)
        {
            _activeBuffsCount++;
            _yPosTemp += YPosIncrement * SizeModifier;
            float xJump = CalculateJump();

            BorderBrush.DrawRectangle(hudWidth * _xPosTemp - (lWidth * 1.05f * .5f) + xJump, hudHeight * _yPosTemp - lHeight * 1.1f, lWidth * 1.05f, lHeight * 1.2f);
            label.DrawRectangle(hudWidth * _xPosTemp - lWidth * .5f + xJump, hudHeight * _yPosTemp - lHeight, lWidth, lHeight);

            var layout = TextFont.GetTextLayout(buffText);
            TextFont.DrawText(layout, hudWidth * _xPosTemp - (layout.Metrics.Width * 0.5f) + xJump, hudHeight * _yPosTemp - (layout.Metrics.Height * 1.1f));

        }

        private float CalculateJump()
        {
            float xJump = lWidth * JumpDistance * _jumpCount;
            if (_yPosTemp >= (YPos + (YPosIncrement * SizeModifier * .9f * (NumRows))))
            {
                _yPosTemp = YPos;
                _jumpCount += 1;
            }
            return xJump;
        }

        private void CalculateXPosTemp()
        {
            var jump = _jumpCount;
            if (_activeBuffsCount % NumRows == 0)
            {
                jump = (_activeBuffsCount-1) / NumRows;
                _xPosGoal = (_jumpCount < 1) ? XPos : (float)(XPos - (_labelWidthPercentage * SizeModifier * ((_activeBuffsCount * .01f) + 1) * (jump)) / 2);
            }
            if (SmoothMovement)
            {
                if (_xPosTemp < _xPosGoal) _xPosTemp += (_xPosGoal - _xPosTemp) * SmoothSpeed;
                if (_xPosTemp > _xPosGoal) _xPosTemp -= (_xPosTemp - _xPosGoal) * SmoothSpeed;
            }
            else _xPosTemp = _xPosGoal;
        }

        private void DebugTimedAdd()
        {
            if (!_debugStarted)
            {
                _debugLabels = new List<Label>();
                foreach (Label l in Labels)
                    _debugLabels.Add(l);
                Labels.Clear();
                _debugStarted = true;
            }

            int time = (int)debugWatch.ElapsedMilliseconds / 1000;
            if (time != _debugAddShifter)
                _debugAlreadyAdded = false;
            if (time % 2 == 0 && !_debugAlreadyAdded)
            {
                _debugAlreadyAdded = true;
                _debugAddShifter = time;
                var layout1 = TextFont.GetTextLayout("" + time);
                TextFont.DrawText(layout1, hudWidth * 0.2f - (layout1.Metrics.Width * 0.5f), hudHeight * .15f);

                Labels.Add(_debugLabels[0]);
                _debugLabels.RemoveAt(0);
            }
            if (_debugLabels.Count == 0)
                _debugDone = true;
        }

    }

    public class Label
    {
        public string NameText { get; set; }
        public int Sno { get; set; }
        public int IconCount { get; set; }
        public IBrush LabelBrush { get; set; }
        public bool Show { get; set; }

        public Label(string NameText, int Sno, int IconCount, IBrush LabelBrush)
        {
            this.NameText = NameText;
            this.Sno = Sno;
            this.IconCount = IconCount;
            this.LabelBrush = LabelBrush;
            Show = true;
        }

        public Label(string NameText, int Sno, int IconCount, IBrush LabelBrush, bool Show)
        {
            this.NameText = NameText;
            this.Sno = Sno;
            this.IconCount = IconCount;
            this.LabelBrush = LabelBrush;
            this.Show = Show;
        }
    }
}
