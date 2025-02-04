﻿using Game;
using Game.FieldAction;
using Game.Specials;

namespace DFZForceFangEquipMod
{
    internal class FangDropRate
    {
        public static bool executeOnSetStatusExecutePrefix(SetStatus __instance, SpecialParam p)
        {
            if (!__instance.T.Status.Contains(Master.CharacterStatus.Fang100))
            {
                return true;
            }
            // 薬によるファングドロップ確定化を無効化
            if (Settings.disableFang100FromItem.Value && p.FromItem != null)
            {
                return false;
            }
            // オブジェクトによるファングドロップ確定化を無効化
            if (Settings.disableFang100FromObj.Value && p.Executer.IsObj)
            {
                return false;
            }
            return true;
        }

        public static bool executeOnPatchForCharacterActionKillCharacterPrefix(CharacterAction.AddDamageOption opt)
        {
            // 戦乙女などのファングドロップ率上昇効果を無効化
            if (Settings.disableFangDropRate.Value)
            {
                opt.FangDropRate = 0;
            }
            return true;
        }
    }
}
