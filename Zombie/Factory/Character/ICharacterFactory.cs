using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace ZombiesVsPlants
{
    public interface ICharacterFactory
    {
        ICharacter CreateCharacter<T>(Point spawnPosition,int posRow,object fm) where T : ICharacter, new();
    }
}
