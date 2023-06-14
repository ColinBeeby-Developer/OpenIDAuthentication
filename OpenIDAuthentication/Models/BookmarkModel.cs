namespace OpenIDAuthentication.Models
{
    public class BookmarkModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the BookmarkTypeId.
        /// </summary>
        public int BookmarkTypeId { get; set; }

        /// <summary>
        /// Gets or sets the ParentId.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the ResourceReferenceId.
        /// </summary>
        public int? ResourceReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the ResourceTypeId.
        /// </summary>
        public int? ResourceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the NodeId.
        /// </summary>
        public int? NodeId { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Link.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the Position.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets the ChildrenCount.
        /// </summary>
        public int ChildrenCount { get; set; }
    }
}
