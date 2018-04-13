using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSoundboard.Model
{
    public class SoundManager
    {
        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allSounds = getSounds();
            // clears the collection if it contains anything
            sounds.Clear();
            // reads in the sounds to the collection
            allSounds.ForEach(p => sounds.Add(p));
        }

        public static void GetSoundsByCategory(ObservableCollection<Sound> sounds, SoundCategory soundCategory)
        {
            var allSounds = getSounds();
            var filteredSounds = allSounds.Where(p => p.Category == soundCategory).ToList();
            // clears the collection if it contains anything
            sounds.Clear();
            // reads in the sounds to the collection
            filteredSounds.ForEach(p => sounds.Add(p));
        }

        private static List<Sound> getSounds()
        {
            var sounds = new List<Sound>();

            //Teams category 
            // grabs the sound using the name and category
            sounds.Add(new Sound("Blue", SoundCategory.Teams));
            sounds.Add(new Sound("Bubbles", SoundCategory.Teams));
            sounds.Add(new Sound("Walk", SoundCategory.Teams));
            sounds.Add(new Sound("Glory", SoundCategory.Teams));
            sounds.Add(new Sound("Spurs", SoundCategory.Teams));

            //Chants category 
            // grabs the sound using the name and category          
            sounds.Add(new Sound("Viva", SoundCategory.Chants));
            sounds.Add(new Sound("Who", SoundCategory.Chants));
            sounds.Add(new Sound("Lose", SoundCategory.Chants));
            sounds.Add(new Sound("Pretend", SoundCategory.Chants));
            sounds.Add(new Sound("Goal", SoundCategory.Chants));

            //Managers category
            // grabs the sound using the name and category
            sounds.Add(new Sound("Jose", SoundCategory.Managers));
            sounds.Add(new Sound("Klopp", SoundCategory.Managers));
            sounds.Add(new Sound("Pep", SoundCategory.Managers));
            sounds.Add(new Sound("W", SoundCategory.Managers));

            //Other category
            // grabs the sound using the name and category
            sounds.Add(new Sound("Charge", SoundCategory.Other));
            sounds.Add(new Sound("Siren", SoundCategory.Other));
            sounds.Add(new Sound("Scores", SoundCategory.Other));
            sounds.Add(new Sound("Rumble", SoundCategory.Other));
            sounds.Add(new Sound("Foot", SoundCategory.Other));

            // returns the sounds
            return sounds;
        }// getSounds
    }// soundManager
}// namespace
