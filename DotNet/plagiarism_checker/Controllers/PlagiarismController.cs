using Microsoft.AspNetCore.Mvc;
using plagiarism_checker.Models;

namespace plagiarism_checker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlagiarismController : ControllerBase
    {
        [HttpPost]
        public IActionResult Analyze([FromBody] PlagiarismRequest request)
        {
            if (request == null)
                return BadRequest("Request body is required.");

            var similarity = SimilarityCalculator.JaccardSimilarity(request.TextA ?? string.Empty, request.TextB ?? string.Empty, 5);

            return Ok(new { percentage = Math.Round(similarity * 100.0, 2) });
        }
    }

    static class SimilarityCalculator
    {
        // Compute Jaccard similarity using character shingles of size k.
        public static double JaccardSimilarity(string a, string b, int k)
        {
            var sa = GetShingles(a ?? string.Empty, k);
            var sb = GetShingles(b ?? string.Empty, k);

            if (sa.Count == 0 && sb.Count == 0)
                return 1.0; // both empty -> identical

            var intersection = 0;
            foreach (var s in sa)
            {
                if (sb.Contains(s)) intersection++;
            }

            var union = sa.Count + sb.Count - intersection;
            if (union == 0) return 0.0;
            return (double)intersection / union;
        }

        private static HashSet<string> GetShingles(string input, int k)
        {
            var normalized = Normalize(input);
            var set = new HashSet<string>();
            if (k <= 0) return set;

            if (normalized.Length <= k)
            {
                if (normalized.Length > 0) set.Add(normalized);
                return set;
            }

            for (int i = 0; i <= normalized.Length - k; i++)
            {
                set.Add(normalized.Substring(i, k));
            }

            return set;
        }

        private static string Normalize(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var sb = new System.Text.StringBuilder(s.Length);
            foreach (var ch in s.ToLowerInvariant())
            {
                if (char.IsLetterOrDigit(ch)) sb.Append(ch);
                else if (char.IsWhiteSpace(ch)) sb.Append(' ');
            }
            return sb.ToString().Replace(" ", string.Empty);
        }
    }
}
