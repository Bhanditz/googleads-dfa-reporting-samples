﻿/*
 * Copyright 2015 Google Inc
 *
 * Licensed under the Apache License, Version 2.0(the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using Google.Apis.Dfareporting.v2_5;
using Google.Apis.Dfareporting.v2_5.Data;

namespace DfaReporting.Samples {
  /// <summary>
  /// This example illustrates how to update a report. Updating a report will
  /// modify all fields.
  /// </summary>
  class UpdateReport : SampleBase {
    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This example illustrates how to update a report. Updating a" +
            " report will modify all fields.\n";
      }
    }

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args) {
      SampleBase codeExample = new UpdateReport();
      Console.WriteLine(codeExample.Description);
      codeExample.Run(DfaReportingFactory.getInstance());
    }

    /// <summary>
    /// Run the code example.
    /// </summary>
    /// <param name="service">An initialized Dfa Reporting service object
    /// </param>
    public override void Run(DfareportingService service) {
      long reportId = long.Parse(_T("INSERT_REPORT_ID_HERE"));
      long profileId = long.Parse(_T("INSERT_USER_PROFILE_ID_HERE"));

      String reportName = _T("ENTER_REPORT_NAME_HERE");

      // Retrieve the specified report.
      Report report = service.Reports.Get(profileId, reportId).Execute();

      // Update the report name.
      report.Name = reportName;

      // Insert the updated report.
      Report updatedReport =
          service.Reports.Update(report, profileId, reportId).Execute();

      Console.WriteLine("{0} report with ID {1} was successfully updated.",
          updatedReport.Type, updatedReport.Id);
    }
  }
}