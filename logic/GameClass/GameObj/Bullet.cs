﻿using Preparation.GameData;
using Preparation.Interface;
using Preparation.Utility;

namespace GameClass.GameObj
{
    public abstract class Bullet : ObjOfCharacter   // LHR摸鱼中...
    {
        private int ap;
        /// <summary>
        /// //攻击力
        /// </summary>
        public int AP => ap;

        private readonly bool hasSpear;
        /// <summary>
        /// 是否有矛
        /// </summary>
        public bool HasSpear => hasSpear;

        /*THUAI4的部分，今年拟采用圆形攻击范围
        /// <summary>
        /// 爆炸区域边长
        /// </summary>
        protected abstract uint AttackRangeEdgeLength { get; }
        /// <summary>
        /// 计算击中后爆炸范围
        /// </summary>
        /// <returns>返回爆炸范围，相对自己的相对距离</returns>
        public XYPosition[] GetAttackRange()
        {
            return XYPosition.GetSquareRange(AttackRangeEdgeLength);
        }*/

        private int bulletBombRange;
        /// <summary>
        /// 爆炸区域半径
        /// </summary>
        public abstract double BulletBombRange { get; }
        /// <summary>
        /// 与THUAI4不同的一个攻击判定方案，通过这个函数判断爆炸时能否伤害到target
        /// </summary>
        /// <param name="target">被尝试攻击者</param>
        /// <returns>是否可以攻击到</returns>
        public abstract bool CanAttack(GameObj target);

        protected override bool IgnoreCollideExecutor(IGameObj targetObj)
        {
            if (targetObj is BirthPoint || targetObj.Type == GameObjType.Prop) return true;	// 子弹不会与出生点和道具碰撞
            return false;
        }
        public Bullet(XYPosition initPos, int radius, int initSpeed, int ap, bool hasSpear) : base(initPos, radius, PlaceType.Null)
        {
            this.CanMove = true;
            this.Type = GameObjType.Bullet;
            this.moveSpeed = initSpeed;
            this.ap = ap;
            this.hasSpear = hasSpear;
        }
        public Bullet(Character player,int radius,int initSpeed,int ap):base(player.Position,radius,PlaceType.Null)
        {
            this.CanMove = true;
            this.Type = GameObjType.Bullet;
            this.moveSpeed = initSpeed;
            this.ap = ap;
            this.hasSpear = player.HasSpear;
        }
        public Bullet(XYPosition initPos, Bullet bullet) : base(initPos, bullet.Radius, PlaceType.Null) { }
        public override bool IsRigid => true;	// 默认为true
        public override ShapeType Shape => ShapeType.Circle;	// 默认为圆形
        public abstract Bullet Clone();  //深复制子弹
    }

    internal sealed class AtomBomb : Bullet
    {
        public AtomBomb(XYPosition initPos, int radius, int initSpeed, int ap, bool hasSpear) : base(initPos, radius, initSpeed, ap, hasSpear) { }
        public AtomBomb(Character player, int radius, int initSpeed, int ap) : base(player, radius, initSpeed, ap) { }
        public override bool IsRigid => true;
        public override ShapeType Shape => ShapeType.Circle;
        public override double BulletBombRange => 3 * GameData.basicBulletBombRange;

        public override bool CanAttack(GameObj target)
        {
            // 圆形攻击范围
            return XYPosition.Distance(this.Position, target.Position) <= this.BulletBombRange;
        }
        public override AtomBomb Clone()
        {
            return new AtomBomb(this.Position, this.Radius, this.MoveSpeed, this.AP, this.HasSpear);
        }
    }
}
