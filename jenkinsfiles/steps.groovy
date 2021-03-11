def getRegions(def enviroment) {
    def REGIONS = [
        lab: 'us-east-1'
    ]
    return REGIONS[enviroment]
}

def configs(def enviroment){
    region = getRegions(enviroment)

    baseConfig = [
        "ENV=${enviroment}",
        "DEPLOY_REGION=${region}",
        "INFRA_BUCKET=infraestructura-${enviroment}"
    ]

    config = [
        "ENV=${enviroment}",
        "INFRA_BUCKET=infraestructura-${enviroment}"
    ]

    return config
}

def build_application(def config) {
    withEnv(config) {
        sh 'make build'
        sh 'make create.zip'
        sh 'make upload.zip'
    }
}

def stack_deploy(def config) {
    withEnv(config) {
        sh 'make stack.deploy'
    }
}

return this