﻿using SQLite;

namespace TodoSQLite.Models;

public class Laboratory
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }
    public bool IsWorking { get; set; }
}
