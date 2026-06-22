using System;
using Microsoft.Data.SqlClient;

namespace ProjectMonHoc.Classes
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var db = new MY_DB())
            {
                try
                {
                    db.openConnection();
                    
                    // Create LoginLogs table if not exists
                    string createLoginLogsSql = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='LoginLogs' AND xtype='U')
                        BEGIN
                            CREATE TABLE LoginLogs (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                Username NVARCHAR(50),
                                Status NVARCHAR(20),  -- 'Success' or 'Failed'
                                AttemptTime DATETIME DEFAULT GETDATE(),
                                Reason NVARCHAR(255)
                            )
                        END
                    ";
                    
                    using (var cmd = new SqlCommand(createLoginLogsSql, db.conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khởi tạo Database: " + ex.Message);
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }
    }
}
