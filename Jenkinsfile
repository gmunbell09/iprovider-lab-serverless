def fnSteps = evaluate readTrusted("jenkinsfiles/steps.groovy")

pipeline {
    agent any
    parameters {
      choice(
        name: 'ENVIRONMENT',
        choices: ['lab', 'dev']
      )
      choice(
        name: 'EXECUTE',
        choices: ['DEFAULT', 'DEPLOY_STACK', 'UPDATE_FUNCTION']
      )
    }
    stages {
        stage('Build') {
            steps {
              echo params.ENVIRONMENT
                script {
                  sh 'make create.zip'
                }
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}