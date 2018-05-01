namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public ISong GetSong(string songName)
        {
            if (HasSong(songName))
            {
                return this.songs.FirstOrDefault(s => s.Name == songName);
            }

            return null;
        }

        public bool HasSong(string name)
        {
            return this.songs.Any(s => s.Name == name);
        }

        public ISet GetSet(string setName)
        {
            if (HasSet(setName))
            {
                return this.sets.FirstOrDefault(s => s.Name == setName);
            }

            return null;
        }

        public bool HasSet(string name)

        {
            return this.sets.Any(s => s.Name == name);
        }

        public IPerformer GetPerformer(string performerName)
        {
            if (HasPerformer(performerName))
            {
                return this.performers.FirstOrDefault(p => p.Name == performerName);
            }

            return null;
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Any(p => p.Name == name);
        }
    }
}