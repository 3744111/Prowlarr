using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using NzbDrone.Core.Indexers;
using NzbDrone.Core.Languages;

namespace NzbDrone.Core.Parser.Model
{
    public class ReleaseInfo
    {
        public ReleaseInfo()
        {
            IndexerFlags = new List<IndexerFlag>();
            Categories = new List<IndexerCategory>();
        }

        public string Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? Size { get; set; }
        public string DownloadUrl { get; set; }
        public string InfoUrl { get; set; }
        public string CommentUrl { get; set; }
        public int IndexerId { get; set; }
        public string Indexer { get; set; }
        public int IndexerPriority { get; set; }
        public DownloadProtocol DownloadProtocol { get; set; }
        public int? Grabs { get; set; }
        public int? Files { get; set; }
        public int TvdbId { get; set; }
        public int TvRageId { get; set; }
        public int ImdbId { get; set; }
        public int TmdbId { get; set; }
        public int TraktId { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string BookTitle { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public DateTime PublishDate { get; set; }

        public string PosterUrl { get; set; }

        public string Origin { get; set; }
        public string Source { get; set; }
        public string Container { get; set; }
        public string Codec { get; set; }
        public string Resolution { get; set; }
        public ICollection<string> Genres { get; set; }
        public ICollection<Language> Languages { get; set; }
        public ICollection<Language> Subs { get; set; }
        public ICollection<IndexerCategory> Categories { get; set; }
        public ICollection<IndexerFlag> IndexerFlags { get; set; }

        [JsonIgnore]
        public string State { get; set; }

        public int Age
        {
            get { return DateTime.UtcNow.Subtract(PublishDate).Days; }

            //This prevents manually downloading a release from blowing up in mono
            //TODO: Is there a better way?
            private set { }
        }

        public double AgeHours
        {
            get { return DateTime.UtcNow.Subtract(PublishDate).TotalHours; }

            //This prevents manually downloading a release from blowing up in mono
            //TODO: Is there a better way?
            private set { }
        }

        public double AgeMinutes
        {
            get { return DateTime.UtcNow.Subtract(PublishDate).TotalMinutes; }

            //This prevents manually downloading a release from blowing up in mono
            //TODO: Is there a better way?
            private set { }
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1} [{2}]", PublishDate, Title, Size);
        }

        public virtual string ToString(string format)
        {
            switch (format.ToUpperInvariant())
            {
                case "L": // Long format
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("Guid: " + Guid ?? "Empty");
                    stringBuilder.AppendLine("Title: " + Title ?? "Empty");
                    stringBuilder.AppendLine("Size: " + Size ?? "Empty");
                    stringBuilder.AppendLine("InfoUrl: " + InfoUrl ?? "Empty");
                    stringBuilder.AppendLine("DownloadUrl: " + DownloadUrl ?? "Empty");
                    stringBuilder.AppendLine("Indexer: " + Indexer ?? "Empty");
                    stringBuilder.AppendLine("CommentUrl: " + CommentUrl ?? "Empty");
                    stringBuilder.AppendLine("DownloadProtocol: " + DownloadProtocol ?? "Empty");
                    stringBuilder.AppendLine("TvdbId: " + TvdbId ?? "Empty");
                    stringBuilder.AppendLine("TvRageId: " + TvRageId ?? "Empty");
                    stringBuilder.AppendLine("ImdbId: " + ImdbId ?? "Empty");
                    stringBuilder.AppendLine("TmdbId: " + TmdbId ?? "Empty");
                    stringBuilder.AppendLine("PublishDate: " + PublishDate ?? "Empty");
                    return stringBuilder.ToString();
                default:
                    return ToString();
            }
        }
    }
}
