using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDL2;

namespace SDL2GameEngine
{
    class SoundManager
    {
        public enum SoundType
        {
            SOUND_MUSIC = 0,
            SOUND_SFX = 1
        }

        private static readonly SoundManager _instance = new SoundManager();
        public static SoundManager Instance { get { return _instance; } }

        public bool Load(string fileName, string id, SoundType type)
        {
            if (type == SoundType.SOUND_MUSIC)
            {
                IntPtr music = SDL_mixer.Mix_LoadMUS(fileName);

                if (music == IntPtr.Zero)
                {
                    Console.WriteLine("Cannot load music");
                    return false;
                }

                _musics[id] = music;
                return true;
            }
            if (type == SoundType.SOUND_SFX)
            {
                IntPtr sound = SDL_mixer.Mix_LoadWAV(fileName);

                if (sound == IntPtr.Zero)
                {
                    Console.WriteLine("Cannot load sound");
                    return false;
                }

                _sfxs[id] = sound;
                return true;
            }
            return false;
        }

        public void PlaySound(string id, int loop)
        {
            SDL_mixer.Mix_PlayChannel(-1, _sfxs[id], loop);
        }

        public void PlayMusic(string id, int loop)
        {
            SDL_mixer.Mix_PlayMusic(_musics[id], loop);
        }

        private Dictionary<string, IntPtr> _sfxs = new Dictionary<string, IntPtr>();
        private Dictionary<string, IntPtr> _musics = new Dictionary<string, IntPtr>();

        public SoundManager()
        {
            SDL_mixer.Mix_OpenAudio(22050, SDL_mixer.MIX_DEFAULT_FORMAT, 2, 4096);
        }

    }
}
