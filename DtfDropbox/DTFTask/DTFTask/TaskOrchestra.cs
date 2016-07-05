﻿//=======================================================================================
// Copyright © daenet GmbH Frankfurt am Main, University of Applied Sciences Frankfurt am Main
//
// LICENSED UNDER THE APACHE LICENSE, VERSION 2.0 (THE "LICENSE"); YOU MAY NOT USE THESE
// FILES EXCEPT IN COMPLIANCE WITH THE LICENSE. YOU MAY OBTAIN A COPY OF THE LICENSE AT
// http://www.apache.org/licenses/LICENSE-2.0
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE DISTRIBUTED UNDER THE
// LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED. SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING
// PERMISSIONS AND LIMITATIONS UNDER THE LICENSE.
//=======================================================================================
using System;
using DurableTask;
using System.Threading.Tasks;
using DaenetIntegration;

namespace Daenet.Integration
{

    

    public class TaskOrchestra:TaskOrchestration<string,string>
	{
		public override async Task<string> RunTask (OrchestrationContext context, string input)
		{
			string cname =  await context.ScheduleTask<string>(typeof(AuthenticationTask), input);
            string upload = await context.ScheduleTask<string>(typeof(UploadTask), cname);
            return upload;
		}


	}
}

