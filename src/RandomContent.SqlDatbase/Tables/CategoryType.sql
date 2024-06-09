CREATE TABLE dbo.CategoryType
(
  CategoryTypeId   INT         NOT NULL,
  CategoryTypeName VARCHAR(50) NOT NULL,
  CONSTRAINT pkcCategoryType PRIMARY KEY (CategoryTypeId)
)
GO

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'CategoryType',                                  @value=N'Represents the type of category being represented.',                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'CategoryType', @level2name=N'CategoryTypeId',   @value=N'The identifier of the category type record.',                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'CategoryType', @level2name=N'CategoryTypeName', @value=N'The name of the category type.',                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name=N'CategoryType', @level2name=N'pkcCategoryType',  @value=N'Defines the primary key for the CategoryType table using the CategoryTypeId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
