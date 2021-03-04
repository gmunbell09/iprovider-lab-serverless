.DEFAULT_GOAL := help

## APP VARS ##
PRODUCT       = iprovider
FUNCTION      = lab

## PARAMS VARS
DEPLOY_REGION    ?= us-east-2

## GENERAL VARS ##
ENV                     ?= lab
INFRA_BUCKET            ?= infraestructura-labs
PROJECT_NAME             = $(PRODUCT)-$(ENV)-fn-$(FUNCTION)
LAMBDA_FUNCTION_S3_KEY   = build/lambda/$(ENV)/$(PROJECT_NAME).zip

## INCLUDE TARGETS ##
-include makefiles/*.mk
