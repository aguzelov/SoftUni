namespace PhotoShare.Models
{
    using PhotoShare.Models.Validation;
    using System.Collections.Generic;

    public class Tag
    {
        private ICollection<AlbumTag> albumTags;

        public Tag()
        {
            this.albumTags = new HashSet<AlbumTag>();
        }

        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }

        public ICollection<AlbumTag> AlbumTags
        {
            get { return this.albumTags; }
            set { this.albumTags = value; }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}