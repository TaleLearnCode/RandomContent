CREATE TABLE dbo.Category
(
  CategoryId     INT           NOT NULL IDENTITY(1,1),
  CategoryTypeId INT           NOT NULL,
  CategoryName   NVARCHAR(100) NOT NULL,
  CONSTRAINT pkcCategory PRIMARY KEY CLUSTERED (CategoryId),
  CONSTRAINT fkCategory_CategoryType FOREIGN KEY (CategoryTypeId) REFERENCES dbo.CategoryType (CategoryTypeId)
)
GO

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Category',                                         @value=N'Represents a category of random content to allow for better filtering..',                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Category', @level2name=N'CategoryId',              @value=N'The identifier of the category record.',                                                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Category', @level2name=N'CategoryTypeId',          @value=N'The identifier of the type of category being represented.',                                              @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Category', @level2name=N'CategoryName',            @value=N'The name of the category.',                                                                              @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Category', @level2name=N'pkcCategory',             @value=N'Defines the primary key for the Category table using the CategoryId column.',                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'Category', @level2name=N'fkCategory_CategoryType', @value=N'Defines the relationship between the Category and CategoryType tables using the CategoryTypeId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO