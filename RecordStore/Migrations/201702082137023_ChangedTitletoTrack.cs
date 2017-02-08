namespace RecordStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTitletoTrack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "TrackTitle", c => c.String());
            DropColumn("dbo.Tracks", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tracks", "Title", c => c.String());
            DropColumn("dbo.Tracks", "TrackTitle");
        }
    }
}
