using eXtensoft.Demo.Model;
using eXtensoft.XF.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using eXtensoft.XF.Core.Abstractions;
using System.Data;
using eXtensoft.XF.Data.Abstractions;
using Microsoft.Extensions.Logging;

namespace eXtensoft.Demo.Data
{
    public class ContentItemDataProvider : SqlServerDataProvider<ContentItem>
    {
        private const string idParamname = "@id";
        private const string displayParamname = "@display";
        private const string textParamname = "@text";
        private const string mimeParamname = "@mime";
        private const string tagsParamname = "@tags";
        private const string createAtParamname = "@at";
        private const string createdByParamname = "@by";

        public ContentItemDataProvider(IConnectionStringProvider connectionStringProvider, IResponseFactory<ContentItem> responseFactory, ILogger logger) : base(connectionStringProvider, responseFactory, logger)
        {
            ConnectionStringProvider = connectionStringProvider;
            ResponseFactory = responseFactory;
            Logger = logger;
        }

        //protected override void InitializeGetCommand(SqlCommand cmd, IParameters parameters)
        //{
        //    cmd.CommandType = CommandType.Text;
        //    if (parameters.HasStrategy())
        //    {

        //    }
        //    else
        //    {
        //        cmd.CommandText = "select [id],[display],[text],[tags],[mime],[createdby],[createdat]" +
        //            " from [demo].[contentitem] where [id] = " + idParamname;
        //        cmd.Parameters.AddWithValue(idParamname, parameters.GetValue<int>("id"));
        //    }
        //}

        //protected override void InitializeDeleteCommand(SqlCommand cmd, IParameters parameters)
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "delete from [demo].[contentitem] where [id] = " + idParamname;
        //    cmd.Parameters.AddWithValue(idParamname,parameters.GetValue<int>("id"));
        //}

        //protected override void InitializePostCommand(SqlCommand cmd, ContentItem model)
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "insert into [demo].[contentitem]([display],[text],[tags],[mime],[createdby]) values (" +
        //         displayParamname + "," + textParamname + "," + tagsParamname + "," + mimeParamname + "," + createdByParamname +
        //         ") select [id],[display],[text],[tags],[mime],[createdby],[createdat] from [demo],[contentitem]" +
        //         " where [id] = scope_identity()";
        //    cmd.Parameters.AddWithValue(displayParamname, model.Display);
        //    cmd.Parameters.AddWithValue(textParamname, model.Text);
        //    cmd.Parameters.AddWithValue(tagsParamname, model.Tags.Concat('|'));
        //    cmd.Parameters.AddWithValue(mimeParamname, model.Mime);
        //    cmd.Parameters.AddWithValue(createdByParamname, model.CreatedBy);
        //}

        //protected override void InitializePutCommand(SqlCommand cmd, ContentItem model, IParameters p)
        //{
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "update [demo].[contentitem] set [display] = " + displayParamname + ",[text] =" +
        //        textParamname + ",[tags] = " + tagsParamname + ",[mime] = " + mimeParamname;
        //    cmd.Parameters.AddWithValue(displayParamname, model.Display);
        //    cmd.Parameters.AddWithValue(textParamname, model.Text);
        //    cmd.Parameters.AddWithValue(tagsParamname, model.Tags);
        //    cmd.Parameters.AddWithValue(mimeParamname, model.Mime);
        //    cmd.Parameters.AddWithValue(idParamname, model.Id);

        //}

        //protected override void Borrow(SqlDataReader reader, List<ContentItem> list)
        //{
        //    while (reader.Read())
        //    {
        //        ContentItem item = new ContentItem();
        //        item.Id = reader.GetInt32(reader.GetOrdinal("id")).ToString();
        //        item.Display = reader.GetString(reader.GetOrdinal("display"));
        //        item.Text = reader.GetString(reader.GetOrdinal("text"));
        //        item.Mime = reader.GetString(reader.GetOrdinal("mime"));
        //        string tags = reader.GetString(reader.GetOrdinal("tags"));
        //        item.Tags = ExpandToList(tags);
        //        item.CreatedBy = reader.GetString(reader.GetOrdinal("createdby"));
        //        item.CreatedAt = reader.GetDateTimeOffset(reader.GetOrdinal("createdat")).LocalDateTime;
        //        list.Add(item);
        //    }
        //}

        private List<string> ExpandToList(string tags)
        {
            return (!String.IsNullOrWhiteSpace(tags)) ? new List<string>(tags.Split(new char[] { '|' })) : new List<string>();
        }
    }
}
