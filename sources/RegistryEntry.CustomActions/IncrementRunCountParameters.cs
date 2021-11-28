// WiX Toolset Pills 15mg
// Copyright (C) 2019-2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Globalization;
using Microsoft.Deployment.WindowsInstaller;

namespace DustInTheWind.RegistryEntry.CustomActions
{
    internal class IncrementRunCountParameters
    {
        private readonly Session session;

        public int RunCount
        {
            get
            {
                string rawValue = session["RUNCOUNT"];

                if (string.IsNullOrEmpty(rawValue))
                    return 0;

                if (rawValue.StartsWith("#"))
                    rawValue = rawValue.Substring(1);

                return int.Parse(rawValue);
            }
            set => session["RUNCOUNT"] = value.ToString(CultureInfo.InvariantCulture);
        }

        public IncrementRunCountParameters(Session session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }
    }
}