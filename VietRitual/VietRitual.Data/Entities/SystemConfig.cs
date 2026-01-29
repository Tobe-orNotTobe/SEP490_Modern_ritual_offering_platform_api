using System.ComponentModel.DataAnnotations;

namespace VietRitual.Data.Entities;

public class SystemConfig
{
	[Key]
	public string ConfigKey { get; set; }

    public string ConfigValue { get; set; }

    public string Description { get; set; }

    public string DataType { get; set; }
}