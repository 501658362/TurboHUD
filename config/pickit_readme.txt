
"PICKIT" DOES NOT RELATED TO "PICK UP" SOMETHING.
THIS FILE EVALUATES ITEMS AND RESULTS A LOGICAL VALUE MEANING "KEEP" OR "SELL"

- Rules are evaluated in order, from top to bottom.
- If a line evaluates true, then the item is considered "KEEP" and the evaluation of this file is stopped.
- If none of the lines was evaluated true, the item is considered "SELL".
- There is no need to start a "keep" line with a + sign, because it is the default modifier.
- "FORCE SELL" modifier: a "-" sign at the very beginning of a line means if the line evaluates true, then the item is considered "SELL" and the evaluation of this file is stopped
- If a lines begins with ";" sign then the line is "commented out" and will be not evaluated.

You can search for item group names in \doc\items.txt

operators:
+   more or equal
=   strict equal
<   less
at_least[N, a, b, c, d, ...]  evaluates true when at least N conditions are true from the set of a, b, c, d, ...

quality values:
3-5 = magic
6 = rare (4 stat)
7 = rare (5 stat)
8 = rare (6 stat)
9 = legendary, set

combo stats:
DPS (available on weapons and offhands, calculated from (DMG_LO+DMG_HI)/2, or (OFFH_DMG_LO+OFFH_DMG_ADD/2))
MAIN_STAT (highest roll of STR, DEX, INT)
MAIN_STAT_VITA (MAIN_STAT + VITA)
ANYRES (highest roll of any elemental resist)
ALLRES_ARMOR (ALLRES + ARMOR/10)
ALLRES_ANYRES (ALLRES + ARMOR/10 + ANYRES)

processed attributes
--------------------

REG_MANA, REG_AP, REG_FURY, REG_SPIRIT, REG_HATRED, REG_DISC, REG_WRATH
MAX_MANA, MAX_AP, MAX_FURY, MAX_SPIRIT, MAX_HATRED, MAX_DISC, MAX_WRATH

LOH, LOK, LSTEAL - life on hit/kill, life steal
IAS - on armors (see: AS_EXTR on weapons)

STR, DEX, INT, VITA, LIFE, B_ARMOR, E_ARMOR, T_ARMOR, DURA, GF, MF, QUALITY, MOVE
HPGLOBE, HPREG, PICKUP,
LVLREQ, LVLREQRED, EXPBONUS, GEMQUALITY, CCRED, INDEST

ALLRES, ANYRES, PH_RES, F_RES, L_RES, C_RES, P_RES, A_RES

DMG_LO, DMG_HI, CRIT, CRITDMG, APOC, DMG_PBONUS
OFFH_DMG_LO, OFFH_DMG_ADD - this is tricky: "+35-90 Damage" equals to: OFFH_DMG_LO=35 and OFFH_DMG_ADD=55
AS_WEAP - total weapon attack speed (x Attacks per Second)
AS_EXTR - weapons' "Increases Attack Speed by x%" (already calculated into AS_WEAP)
DMG_PBONUS - weapon extra damage (+x% Damage)
SKILLDMG - Increases [skill] Damage by X%
SDMG_ANY, SDMG_PH, SDMG_F, SDMG_L, SDMG_C, SDMG_P, SDMG_A, SDMG_H - ...skills deal X% more damage
RESCOSTRED - Reduces all resource costs by 5%
CDRED - Reduces cooldown of all skills by 5%
ELITEDAM - Increases damage against elites by 5%
ELITEDAMRED - Reduces damage from elites by 5%

B_BLOCK, E_BLOCK, T_BLOCK- base/extra/total block %
THORNS - damage to melee attackers
AREADMG - area damage on hit
SOCK - socket count

CUBED - item is already in the Kanai Cube
CAN_CUBED - item is not in the Kanai Cube but it could be