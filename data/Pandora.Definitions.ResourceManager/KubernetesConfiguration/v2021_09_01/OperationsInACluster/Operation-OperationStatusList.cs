using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.OperationsInACluster;

internal class OperationStatusListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ClusterResourceId();

    public override Type NestedItemType() => typeof(OperationStatusResultModel);

    public override string? UriSuffix() => "/providers/Microsoft.KubernetesConfiguration/operations";


}
