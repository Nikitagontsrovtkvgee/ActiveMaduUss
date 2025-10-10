using System;
#if WINDOWS
using System.Media;
#endif

namespace SnakeGame
{
    public class SoundManager
    {
#if WINDOWS
        private readonly SoundPlayer startSound = new SoundPlayer("start.wav");
        private readonly SoundPlayer gameOverSound = new SoundPlayer("gameover.wav");
        private readonly SoundPlayer bonusSound = new SoundPlayer("bonus.wav");
        private readonly SoundPlayer boosterSound = new SoundPlayer("booster.wav");
        private readonly SoundPlayer bombSpawnSound = new SoundPlayer("bombspawn.wav");
        private readonly SoundPlayer explosionSound = new SoundPlayer("explosion.wav");
        private readonly SoundPlayer endSound = new SoundPlayer("end.wav");
#endif

        public void PlayStart() => PlaySound(() =>
        {
#if WINDOWS
            startSound.Play();
#else
            // Заглушка для других платформ
#endif
        });

        public void PlayGameOver() => PlaySound(() =>
        {
#if WINDOWS
            gameOverSound.Play();
#endif
        });

        public void PlayBonus() => PlaySound(() =>
        {
#if WINDOWS
            bonusSound.Play();
#endif
        });

        public void PlayBooster() => PlaySound(() =>
        {
#if WINDOWS
            boosterSound.Play();
#endif
        });

        public void PlayBombSpawn() => PlaySound(() =>
        {
#if WINDOWS
            bombSpawnSound.Play();
#endif
        });

        public void PlayExplosion() => PlaySound(() =>
        {
#if WINDOWS
            explosionSound.Play();
#endif
        });

        public void PlayEnd() => PlaySound(() =>
        {
#if WINDOWS
            endSound.Play();
#endif
        });

        private void PlaySound(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                // заглушка на случай ошибок
            }
        }
    }
}
