using System;
using System.Collections.Generic;
using System.Text;


namespace ZombiesVsPlants
{
    public class BulletAttrFactory
    {
        private Dictionary<Type, BulletBaseAttr> mBulletBaseAttrDict;
        public BulletAttrFactory()
        {
            InitBulletBaseAttr();
        }
        private void InitBulletBaseAttr()
        {
            mBulletBaseAttrDict = new Dictionary<Type, BulletBaseAttr>();
            mBulletBaseAttrDict.Add(typeof(SingleBullet), new BulletBaseAttr(Bulletype.single, 25, 15, 0, ZombiesVsPlants.FilesPath.PlantsBullet, ZombiesVsPlants.FilesPath.PlantsBulletHits));
        }
        public BulletBaseAttr GetCharacterBaseAttr(Type t)
        {
            if (mBulletBaseAttrDict.ContainsKey(t) == false)
            {
                return null;
            }
            return mBulletBaseAttrDict[t];
        }
    }
}
