using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;
using CitizenFX.Core.NaturalMotion;
using CitizenFX.Core.UI;

namespace FlyingVehicleCrashFix
{
    public class Main : BaseScript
    {
        public Main()
        {
            Tick += PlaneHandler;
        }

        public async Task PlaneHandler()
        {
            foreach(Vehicle v in World.GetAllVehicles())
            {
                if(v != null)
                {
                    if (v.IsInAir)
                    {
                        if (v != null)
                        {
                            if (v.ClassType == VehicleClass.Planes)
                            {
                                if (v != null)
                                {
                                    if (IsVehicleOwnedByAnyPlayer(v, true) == false)
                                    {
                                        if (v != null)
                                        {
                                            Debug.WriteLine("[DEBUG] Deleted Vehicle with handle " + v.Handle.ToString() + " and model " + v.Model.ToString());
                                            v.Delete();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            await Delay(100);
        }

        private List<Player> GetAllPlayers()
        {
            List<Player> AllPlayers = new List<Player>() { };
            dynamic Players = GetActivePlayers();

            foreach (int index in Players)
            {
                AllPlayers.Add(new Player(index));
            }

            return AllPlayers;
        }

        private bool IsVehicleOwnedByAnyPlayer(Vehicle v, bool InsideVehicle)
        {
            
            foreach(Player p in GetAllPlayers()) 
            {
                if (p.LastVehicle != null && v != null)
                {
                    if (p.LastVehicle == v)
                    {
                        if(InsideVehicle == true)
                        {
                            if(v.GetPedOnSeat(VehicleSeat.Driver) == p.Character)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
