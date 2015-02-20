require 'albacore'

task :default => :build

# Builds the web application into the 'Build' folder
build :build do |msb|
	msb.target = "Build"
	msb.sln    = 'MarkdownServer.sln'

	msb.prop :DeployOnBuild , 'true'
	msb.prop :PublishProfile, 'Build'
end
