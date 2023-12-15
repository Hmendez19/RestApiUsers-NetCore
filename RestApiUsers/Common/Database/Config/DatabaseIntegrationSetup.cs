using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace RestApiUsers.Common.Database.Config;

public class DatabaseIntegrationSetup
{
    public Configuration GetDataBaseIntegration()
    {
        var configuration = new Configuration();
        configuration.DataBaseIntegration(db =>
        {
            db.ConnectionString = "Server=localhost;Port=3306;Database=testing_net;User ID=root;Password=mauFJcuf5dhRMQrjj;";
            db.Dialect<MySQLDialect>();
            db.Driver<MySqlDataDriver>();
            db.KeywordsAutoImport= Hbm2DDLKeyWords.AutoQuote;
            db.SchemaAction = SchemaAutoAction.Validate;
            db.SchemaAction = SchemaAutoAction.Update;
            db.LogFormattedSql = true;
            db.LogSqlInConsole = true;
        });

        return configuration;
    }
}