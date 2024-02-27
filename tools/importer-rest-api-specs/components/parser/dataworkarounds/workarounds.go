// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var workarounds = []workaround{
	// These workarounds are related to issues with the upstream API Definitions
	workaroundAuthorization25080{},
	workaroundDigitalTwins25120{},
	workaroundAutomation25108{},
	workaroundAutomation25435{},
	workaroundBatch21291{},
	workaroundBotService27351{},
	workaroundContainerService21394{},
	workaroundDataFactory23013{},
	workaroundHDInsight26838{},
	workaroundLoadTest20961{},
	workaroundRedis22407{},
	workaroundMachineLearning25142{},
	workaroundOperationalinsights26678{},
	workaroundOperationalinsights27524{},
	workaroundRecoveryServicesSiteRecovery26680{},
	workaroundStreamAnalytics27577{},

	// These workarounds relate to Terraform specific overrides we want to apply (for example for Resource Generation)
	workaroundDevCenterIdToRequired{},

	// These workarounds relate to data inconsistencies
	workaroundInconsistentlyDefinedSegments{},
	workaroundInvalidGoPackageNames{},
}

func ApplyWorkarounds(input []importerModels.AzureApiDefinition, logger hclog.Logger) (*[]importerModels.AzureApiDefinition, error) {
	output := make([]importerModels.AzureApiDefinition, 0)
	logger.Trace("Processing Swagger Data Workarounds..")
	for _, item := range input {
		for _, fix := range workarounds {
			if fix.IsApplicable(&item) {
				logger.Trace(fmt.Sprintf("Applying Swagger Data Workaround %q to Service %q / API Version %q", fix.Name(), item.ServiceName, item.ApiVersion))
				updated, err := fix.Process(item)
				if err != nil {
					return nil, fmt.Errorf("applying Swagger Data Workaround %q to Service %q / API Version %q: %+v", fix.Name(), item.ServiceName, item.ApiVersion, err)
				}

				item = *updated
			}
		}
		output = append(output, item)
	}

	return &output, nil
}
