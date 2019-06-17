using System;
using System.Collections.Generic;
using System.Text;


namespace ZombiesVsPlants
{
    public interface IAttrFactory
    {
        CharacterBaseAttr GetCharacterBaseAttr(System.Type t);
    }
}
