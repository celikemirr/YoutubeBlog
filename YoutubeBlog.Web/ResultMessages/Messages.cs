namespace YoutubeBlog.Web.ResultMessages
{
	public static class Messages
	{
		public static class Article
		{
			public static string Add(string articleTitle)
			{
				return $"{articleTitle} Article completed successfully";
			}
			public static string Update(string articleTitle)
			{
				return $"{articleTitle} Article updated successfully";
			}
			public static string Delete(string articleTitle)
			{
				return $"{articleTitle} Article deleted successfully";
			}
		}
	}
}
