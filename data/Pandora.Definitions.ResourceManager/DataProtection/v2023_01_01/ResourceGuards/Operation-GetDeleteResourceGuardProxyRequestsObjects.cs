using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_01_01.ResourceGuards;

internal class GetDeleteResourceGuardProxyRequestsObjectsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ResourceGuardId();

    public override Type NestedItemType() => typeof(DppBaseResourceModel);

    public override string? UriSuffix() => "/deleteResourceGuardProxyRequests";


}
