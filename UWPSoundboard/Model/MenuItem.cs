using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSoundboard.Model
{
    public class MenuItem
    {
        //generates getters and setters for the menu items
        public string IconFile { get; set; }
        public SoundCategory Category { get; set; }
    }
}
