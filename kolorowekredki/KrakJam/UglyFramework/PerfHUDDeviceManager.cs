﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UglyFramework
{
    public class PerfHUDDeviceManager : GraphicsDeviceManager
    {
        public bool PerfHUDActive = false;

        public PerfHUDDeviceManager(Microsoft.Xna.Framework.Game game)
            : base(game)
        {
        }

        protected override void RankDevices(List<GraphicsDeviceInformation> foundDevices)
        {
            base.RankDevices(foundDevices);

            bool foundPerfHud = false;

            foreach (var device in foundDevices)
            {
                if (device.Adapter.Description.Contains("PerfHUD"))
                {
                    foundPerfHud = true;
                    break;
                }
            }

            if (foundPerfHud)
            {
                var temp = foundDevices.OrderBy(
                    (gdi) => !(gdi.Adapter.Description.Contains("PerfHUD"))
                ).ToArray();

                foundDevices.Clear();
                foundDevices.AddRange(temp);

                foreach (var dev in foundDevices)
                    dev.DeviceType = DeviceType.Reference;

            }

            PerfHUDActive = foundPerfHud;
        }
    }
}
