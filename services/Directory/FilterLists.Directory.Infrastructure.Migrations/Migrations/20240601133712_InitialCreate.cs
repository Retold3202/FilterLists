﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilterLists.Directory.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iso6391 = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    PermitsModification = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PermitsDistribution = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PermitsCommercialUse = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TwitterHandle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DownloadUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    SupportsAbpUrlScheme = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syntaxes",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syntaxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilterLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseId = table.Column<int>(type: "int", nullable: false, defaultValue: 5),
                    HomeUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    OnionUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    PolicyUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    SubmissionUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    IssuesUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ForumUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ChatUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DonateUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterLists_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareSyntax",
                columns: table => new
                {
                    SoftwareId = table.Column<short>(type: "smallint", nullable: false),
                    SyntaxId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareSyntax", x => new { x.SoftwareId, x.SyntaxId });
                    table.ForeignKey(
                        name: "FK_SoftwareSyntax_Software_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Software",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareSyntax_Syntaxes_SyntaxId",
                        column: x => x.SyntaxId,
                        principalTable: "Syntaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    DependencyFilterListId = table.Column<int>(type: "int", nullable: false),
                    DependentFilterListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => new { x.DependencyFilterListId, x.DependentFilterListId });
                    table.ForeignKey(
                        name: "FK_Dependent_FilterLists_DependencyFilterListId",
                        column: x => x.DependencyFilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dependent_FilterLists_DependentFilterListId",
                        column: x => x.DependentFilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilterListLanguage",
                columns: table => new
                {
                    FilterListId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterListLanguage", x => new { x.FilterListId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_FilterListLanguage_FilterLists_FilterListId",
                        column: x => x.FilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilterListLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterListMaintainer",
                columns: table => new
                {
                    FilterListId = table.Column<int>(type: "int", nullable: false),
                    MaintainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterListMaintainer", x => new { x.FilterListId, x.MaintainerId });
                    table.ForeignKey(
                        name: "FK_FilterListMaintainer_FilterLists_FilterListId",
                        column: x => x.FilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilterListMaintainer_Maintainers_MaintainerId",
                        column: x => x.MaintainerId,
                        principalTable: "Maintainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterListSyntax",
                columns: table => new
                {
                    FilterListId = table.Column<int>(type: "int", nullable: false),
                    SyntaxId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterListSyntax", x => new { x.FilterListId, x.SyntaxId });
                    table.ForeignKey(
                        name: "FK_FilterListSyntax_FilterLists_FilterListId",
                        column: x => x.FilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilterListSyntax_Syntaxes_SyntaxId",
                        column: x => x.SyntaxId,
                        principalTable: "Syntaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterListTag",
                columns: table => new
                {
                    FilterListId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterListTag", x => new { x.FilterListId, x.TagId });
                    table.ForeignKey(
                        name: "FK_FilterListTag_FilterLists_FilterListId",
                        column: x => x.FilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilterListTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterListViewUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilterListId = table.Column<int>(type: "int", nullable: false),
                    SegmentNumber = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    Primariness = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    Url = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterListViewUrl", x => new { x.FilterListId, x.Id });
                    table.ForeignKey(
                        name: "FK_FilterListViewUrl_FilterLists_FilterListId",
                        column: x => x.FilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fork",
                columns: table => new
                {
                    UpstreamFilterListId = table.Column<int>(type: "int", nullable: false),
                    ForkFilterListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fork", x => new { x.UpstreamFilterListId, x.ForkFilterListId });
                    table.ForeignKey(
                        name: "FK_Fork_FilterLists_ForkFilterListId",
                        column: x => x.ForkFilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fork_FilterLists_UpstreamFilterListId",
                        column: x => x.UpstreamFilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Merge",
                columns: table => new
                {
                    IncludedInFilterListId = table.Column<int>(type: "int", nullable: false),
                    IncludesFilterListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merge", x => new { x.IncludedInFilterListId, x.IncludesFilterListId });
                    table.ForeignKey(
                        name: "FK_Merge_FilterLists_IncludedInFilterListId",
                        column: x => x.IncludedInFilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Merge_FilterLists_IncludesFilterListId",
                        column: x => x.IncludesFilterListId,
                        principalTable: "FilterLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_DependentFilterListId",
                table: "Dependent",
                column: "DependentFilterListId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterListLanguage_LanguageId",
                table: "FilterListLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterListMaintainer_MaintainerId",
                table: "FilterListMaintainer",
                column: "MaintainerId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterLists_LicenseId",
                table: "FilterLists",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterLists_Name",
                table: "FilterLists",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilterListSyntax_SyntaxId",
                table: "FilterListSyntax",
                column: "SyntaxId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterListTag_TagId",
                table: "FilterListTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterListViewUrl_FilterListId_SegmentNumber_Primariness",
                table: "FilterListViewUrl",
                columns: new[] { "FilterListId", "SegmentNumber", "Primariness" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fork_ForkFilterListId",
                table: "Fork",
                column: "ForkFilterListId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Iso6391",
                table: "Languages",
                column: "Iso6391",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_Name",
                table: "Licenses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maintainers_Name",
                table: "Maintainers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merge_IncludesFilterListId",
                table: "Merge",
                column: "IncludesFilterListId");

            migrationBuilder.CreateIndex(
                name: "IX_Software_Name",
                table: "Software",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareSyntax_SyntaxId",
                table: "SoftwareSyntax",
                column: "SyntaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Syntaxes_Name",
                table: "Syntaxes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "FilterListLanguage");

            migrationBuilder.DropTable(
                name: "FilterListMaintainer");

            migrationBuilder.DropTable(
                name: "FilterListSyntax");

            migrationBuilder.DropTable(
                name: "FilterListTag");

            migrationBuilder.DropTable(
                name: "FilterListViewUrl");

            migrationBuilder.DropTable(
                name: "Fork");

            migrationBuilder.DropTable(
                name: "Merge");

            migrationBuilder.DropTable(
                name: "SoftwareSyntax");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Maintainers");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "FilterLists");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Syntaxes");

            migrationBuilder.DropTable(
                name: "Licenses");
        }
    }
}
