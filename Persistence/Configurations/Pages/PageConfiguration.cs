namespace Persistence.Configurations.Pages
{
    internal class PageConfiguration : object,
        Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Cms.Page>
    {
        public PageConfiguration() : base()
        {

        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders
            .EntityTypeBuilder<Domain.Cms.Page> builder)
        {
            builder
                .Property(p => p.Title)
                .IsRequired(required: true)
                .HasMaxLength(maxLength: Domain.Cms.Page.TitleMaximumLength)
                ;

            builder
                .Property(p => p.Description)
                .HasMaxLength(maxLength: Domain.Cms.Page.DescriptionMaximumLength)
                ;

            builder
                .Property(p => p.Author)
                .HasMaxLength(maxLength: Domain.Cms.Page.AuthorMaximumLength)
                ;

            builder
                .Property(p => p.Keywords)
                .HasMaxLength(maxLength: Domain.Cms.Page.KeywordsMaximumLength)
                ;

            builder
                .Property(p => p.InsertDateTime)
                .IsRequired(required: true)
                ;

            builder
                .Property(p => p.CreatorUserId)
                .IsRequired(required: true)
                ;
        }
    }
}
