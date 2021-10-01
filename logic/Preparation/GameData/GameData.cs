﻿using Preparation.Utility;

namespace Preparation.GameData
{
    public static class GameData
    {
        public const int numOfPosGridPerCell = 1000;            // 每格的【坐标单位】数
        public const int numOfStepPerSecond = 20;               // 每秒行走的步数
        public const int lengthOfMap = 50000;                   // 地图长度
        public const long gameDuration = 600000;                // 游戏时长600000ms = 10min 
        public const long frameDuration = 50;                   // 每帧时长

        public const int MinSpeed = 1;             //最小速度
        public const int MaxSpeed = int.MaxValue;  //最大速度

        public static XYPosition GetCellCenterPos(int x, int y)   // 求格子的中心坐标
        {
            XYPosition ret = new XYPosition(x * numOfPosGridPerCell + numOfPosGridPerCell / 2,
                y * numOfPosGridPerCell + numOfPosGridPerCell / 2);
            return ret;
        }
        public static int PosGridToCellX(XYPosition pos)       // 求坐标所在的格子的x坐标
        {
            return pos.x / numOfPosGridPerCell;
        }
        public static int PosGridToCellY(XYPosition pos)      // 求坐标所在的格子的y坐标
        {
            return pos.y / numOfPosGridPerCell;
        }
        /// <summary>
        /// 玩家相关
        /// </summary>
        public const int basicAp = 1000;	// 初始攻击力
        public const int basicHp = 6000;	// 初始血量
        public const int basicCD = 1000;    // 初始子弹冷却
        public const int basicBulletNum = 5;   // 初始子弹量
        public const int MinAP = 0; // 最小攻击力
        public const int MaxAP = int.MaxValue;  //最大攻击力
        public const double basicAttackRange = 4000;               // 基本攻击范围
        public const double basicBulletBombRange = 5000;           // 基本子弹爆炸范围
        public const int basicMoveSpeed = 10;                   // 基本移动速度
        public const int basicBulletMoveSpeed = 10;             // 基本子弹移动速度
        public const int addScoreWhenKillOneLevelPlayer = 10;   // 击杀一级角色获得的加分
        public const int scoreInrease = 2;                      // 每高一级，击杀该角色多的加分
        public const int commonSkillCD = 30000;    //普通技能标准冷却时间
        public const int commonSkillTime = 10000;  //普通技能标准持续时间
        public const int bulletRadius = 200;       //默认子弹半径
        /// <summary>
        /// 道具相关
        /// </summary>
        public const int MinPropTypeNum = 1;
        public const int MaxPropTypeNum = 10;
    }
}