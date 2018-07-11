using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Linq;

namespace PhotoShare.Services
{
    public class TagService : ITagService
    {
        private readonly PhotoShareContext context;

        public TagService(PhotoShareContext context)
        {
            this.context = context;
        }

        public Tag GetTagByName(string tagName)
        {
            if (!Exist(tagName))
            {
                throw new ArgumentException($"Invalid tags!");
            }

            return context.Tags.First(t => t.Name == tagName);
        }

        public Tag AddTag(string tagName)
        {
            Tag tag = new Tag
            {
                Name = tagName
            };

            if (Exist(tagName))
            {
                throw new ArgumentException($"Tag {tag} exists!");
            }

            context.Tags.Add(tag);

            context.SaveChanges();

            return tag;
        }

        public bool Exist(string tagName)
        {
            return context.Tags.Any(t => t.Name == tagName);
        }
    }
}