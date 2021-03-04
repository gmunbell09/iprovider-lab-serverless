pipeline {
  agent any
  parameters {
    choice(
      name: 'ENVIRONMENT',
      choices: ['dev', 'pre', 'prod']
    )
    choice(
      name: 'EXECUTE',
      choices: ['DEFAULT', 'DEPLOY_STACK', 'UPDATE_FUNCTION']
    )
  }
  stages {
    stage('Build') {
      steps {
          echo 'Building'
        }
      }
    }
  }
  post {
    always {
      cleanWs()
    }
  }
}