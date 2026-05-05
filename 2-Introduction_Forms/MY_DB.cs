using Microsoft.Data.SqlClient;

class MY_DB
{
    // Khai báo kết nối
    SqlConnection con = new SqlConnection(
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=myDB;Integrated Security=True"
    );

    // Lấy connection
    public SqlConnection getConnection
    {
        get { return con; }
    }

    // Mở kết nối
    public void openConnection()
    {
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
    }

    // Đóng kết nối
    public void closeConnection()
    {
        if (con.State == System.Data.ConnectionState.Open)
            con.Close();
    }
}