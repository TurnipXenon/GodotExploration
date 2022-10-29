namespace GodotExploration.Scripts.Common;

public static class ResourcePaths
{
	private const string BasePath = "res://Scripts/Scenes";

	public static class Breakout
	{
		private const string BreakoutBasePath = $"{BasePath}/Breakout";
		public static class BreakoutMenu
		{
			private const string BreakoutMenuBasePath = $"{BreakoutBasePath}/BreakoutMenu";
			public const string BreakoutMenuScene = $"{BreakoutMenuBasePath}/BreakoutMenu.tscn";
		}
	}

	public static class MainMenu
	{
		private const string MainMenuBasePath = $"{BasePath}/MainMenu";
		public const string MainMenuScene = $"{MainMenuBasePath}/MainMenu.tscn";
	}
	
	public static class SimplePong
	{
		private const string SimplePongBasePath = $"{BasePath}/simple_pong";
		public static class Menu
		{
			private const string MenuBasePath = $"{SimplePongBasePath}/menu";
			public const string PongMenuScene = $"{MenuBasePath}/PongMenu.tscn";
		}
	}
}
