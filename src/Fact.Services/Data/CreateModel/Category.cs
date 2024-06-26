﻿using Microsoft.EntityFrameworkCore;
using TaleLearnCode.RandomContent.Facts.Data.Models;

namespace TaleLearnCode.RandomContent.Facts.Data;

internal static partial class CreateModel
{
	internal static void Category(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Category>(entity =>
		{
			entity.HasKey(e => e.CategoryId).HasName("pkcCategory");

			entity.ToTable("Category");

			entity.Property(e => e.CategoryName)
					.IsRequired()
					.HasMaxLength(100);
		});
	}
}