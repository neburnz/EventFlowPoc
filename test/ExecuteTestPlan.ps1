$Env:Path += ";C:\Software\apache-jmeter-5.2\bin"

$executionDate = Get-Date -Format "yyyy_MM_dd_HHmmss"

$testPlanFile = "C:\Users\Admin\OneDrive - AN Global\Projects\EventFlow\poc\test\SIFACE.Monitor - Test Plan.jmx"
$testResultsFile = "C:\Users\Admin\OneDrive - AN Global\Projects\EventFlow\poc\test\test_results_$($executionDate).jtl"

jmeter.bat -n -t "$($testPlanFile)" -l "$($testResultsFile)"

$dashboardFolder = "C:\Users\Admin\OneDrive - AN Global\Projects\EventFlow\poc\test\dashboard_$($executionDate)"

jmeter.bat -g "$($testResultsFile)" -o "$($dashboardFolder)"