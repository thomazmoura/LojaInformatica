Param(
    [string]$token,
    [string]$branch,
    [string]$repository
)

$pushUrl = "https://$token@github.com/thomazmoura/$repository.git";
$branchRef = "head:$branch"

if ($branch.Contains("dev") -Or $branch.Contains("master")) {
    git.exe push --force $pushUrl $branchRef;
    Write-Host "Branch $branch updated on GitHub";
}
else {
    Write-Host "Branch $branch ignored on GitHub";  
}
