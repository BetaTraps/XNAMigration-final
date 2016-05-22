using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace XNAMigration
{
    class MusicAndSound
    {
        Song song;
        SoundEffect effect;

        ContentManager Content;

        public MusicAndSound(ContentManager content)
        {
           Content = content;
        }

        public MusicAndSound() { }

        public void LoadBackgroundSong(string SongName)
        {
            song = Content.Load<Song>(SongName); // load the song

            MediaPlayer.Play(song); // Start the song
        }

        public void LoadSoundEffect(string EffectName)
        {
            effect = Content.Load<SoundEffect>(EffectName);
            effect.Play();
        }
    }
}
