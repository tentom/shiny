﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Samples.Infrastructure;
using Samples.Models;


namespace Samples.HttpTransfers
{
    public class LogViewModel : AbstractLogViewModel<CommandItem>
    {
        readonly SampleSqliteConnection conn;


        public LogViewModel(IUserDialogs dialogs,
                            SampleSqliteConnection conn) : base(dialogs)
        {
            this.conn = conn;
        }


        protected override Task ClearLogs() => this.conn.DeleteAllAsync<HttpEvent>();

        protected override async Task<IEnumerable<CommandItem>> LoadLogs()
        {
            var events = await this.conn
                .HttpEvents
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync();

            return Enumerable.Empty<CommandItem>();
        }
    }
}