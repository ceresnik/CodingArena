/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2019. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
namespace CodingArena.Player
{
    public interface IRobot
    {
        int HealthPoints { get; }
        double HealthPercentage { get; }
        int ShieldPoints { get; }
        double ShieldPercentage { get; }
    }
}