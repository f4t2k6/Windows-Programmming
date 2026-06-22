using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;

namespace ProjectMonHoc.Classes
{
    public class FaceRecognizerHelper
    {
        private LBPHFaceRecognizer _recognizer;
        private string _modelPath;
        private string _labelsPath;
        
        // Dictionary mapping int label to Username
        public Dictionary<int, string> LabelMap { get; private set; }

        public FaceRecognizerHelper(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            _modelPath = Path.Combine(directoryPath, "trained_model.yml");
            _labelsPath = Path.Combine(directoryPath, "labels.json");
            
            _recognizer = new LBPHFaceRecognizer();
            LabelMap = new Dictionary<int, string>();
            
            LoadModel();
        }

        public void LoadModel()
        {
            if (File.Exists(_modelPath))
            {
                _recognizer.Read(_modelPath);
            }
            if (File.Exists(_labelsPath))
            {
                string json = File.ReadAllText(_labelsPath);
                var map = JsonSerializer.Deserialize<Dictionary<int, string>>(json);
                if (map != null) LabelMap = map;
            }
        }

        public void SaveModel()
        {
            _recognizer.Write(_modelPath);
            string json = JsonSerializer.Serialize(LabelMap);
            File.WriteAllText(_labelsPath, json);
        }

        public void TrainModel(List<Image<Gray, byte>> faceImages, int label, string username)
        {
            // If the user already exists in LabelMap, we use their existing label or overwrite
            LabelMap[label] = username;
            
            // Note: LBPH in EmguCV update() requires arrays.
            // If it's a completely new model, we use Train, if existing, we use Update
            using (var vectorImages = new Emgu.CV.Util.VectorOfMat())
            using (var vectorLabels = new Emgu.CV.Util.VectorOfInt())
            {
                foreach (var img in faceImages)
                {
                    vectorImages.Push(img.Mat);
                    vectorLabels.Push(new int[] { label });
                }

                if (File.Exists(_modelPath))
                {
                    _recognizer.Update(vectorImages, vectorLabels);
                }
                else
                {
                    _recognizer.Train(vectorImages, vectorLabels);
                }
            }
            
            SaveModel();
        }

        // Returns predicted username and confidence distance (lower is better, < 80 is usually good)
        public (string username, double distance) Predict(Image<Gray, byte> faceImage)
        {
            if (!File.Exists(_modelPath)) return ("", 9999);
            
            var result = _recognizer.Predict(faceImage);
            if (LabelMap.ContainsKey(result.Label))
            {
                return (LabelMap[result.Label], result.Distance);
            }
            return ("", result.Distance);
        }
    }
}
