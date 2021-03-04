def getRegions(def enviroment) {
    def REGIONS = [
        dev: 'us-east-1'
    ]
    return REGIONS[enviroment]
}