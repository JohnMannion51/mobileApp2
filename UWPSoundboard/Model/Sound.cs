using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSoundboard.Model
{
    public class Sound
    {
        // generates getters and setters 
        public string Name { get; set; }
        public SoundCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }

        public Sound(string name, SoundCategory category)
        {
            Name = name;
            Category = category;
            // sets the audio format to wav and the image format to png 
            // the files will be retrieved using the category and name
            AudioFile = String.Format("/Assets/Audio/{0}/{1}.wav", category, name);
            ImageFile = String.Format("/Assets/Images/{0}/{1}.png", category, name);

        }

    }

    public enum SoundCategory
    {
        // creates 4 enum categories for binding the images to the sounds
        Teams,
        Chants,
        Managers,
        Other
    }
}
