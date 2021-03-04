def getRegions(def enviroment) {
    def REGIONS = [
        lab: 'us-east-1'
    ]
    return REGIONS[enviroment]
}


def build_application(def enviroment) {
    sh 'make create.zip'
    sh 'upload.zip'
}