require 'albacore'

task :default => :build

# Builds the web application into the 'Build' folder
msbuild :build do |msb|
	msb.targets :Build
	msb.properties = { :DeployOnBuild => 'true', :PublishProfile => 'Build' }
	msb.solution = 'MarkdownServer.sln'
end