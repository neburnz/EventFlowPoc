$jmeter_path = $args[0]
$execution_path = $args[1]

$Env:Path += ";$($jmeter_path)"

$executionDate = Get-Date -Format "yyyy_MM_dd_HHmmss"

$testPlanFile = "$($execution_path)\JMeter_Test_Plan.jmx"
$testResultsFile = "$($execution_path)\test_results_$($executionDate).jtl"

jmeter.bat -n -t "$($testPlanFile)" -l "$($testResultsFile)"

$dashboardFolder = "$($execution_path)\dashboard_$($executionDate)"

jmeter.bat -g "$($testResultsFile)" -o "$($dashboardFolder)"