using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.LogAnalytics;

internal class Definition : ResourceDefinition
{
    public string Name => "LogAnalytics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExportRequestRateByIntervalOperation(),
        new ExportThrottledRequestsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(IntervalInMinsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LogAnalyticsInputBaseModel),
        typeof(LogAnalyticsOperationResultModel),
        typeof(LogAnalyticsOutputModel),
        typeof(RequestRateByIntervalInputModel),
    };
}
